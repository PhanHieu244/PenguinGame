namespace ChuongCustom
{
    using UnityEditor;
    using UnityEditor.IMGUI.Controls;
    using UnityEngine;

    [CustomPropertyDrawer(typeof(IAPKeyAttribute))]
    public class IAPKeyDrawer : PropertyDrawer {

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.LabelField(position, label);
        
            var popupPosition = new Rect(position);
            popupPosition.width -= EditorGUIUtility.labelWidth;
            popupPosition.x += EditorGUIUtility.labelWidth;
            popupPosition.height = EditorGUIUtility.singleLineHeight;

            if (!IAPDropDownPopup.INVERSE_CATALOG.ContainsKey(property.stringValue))
            {
                property.stringValue = null;
            }
            
            if (property.stringValue == null) {
                Update(string.Empty, property);
            }
            else if (EditorGUI.DropdownButton(popupPosition, new GUIContent(IAPDropDownPopup.INVERSE_CATALOG[property.stringValue]), FocusType.Keyboard)) {
                var state = new AdvancedDropdownState();
                new IAPDropDownPopup(state, 3)
                {
                    OnItemSelected = item => Update(item, property)
                }.Show(popupPosition);
            }
        
            EditorGUI.EndProperty();
        }

        private void Update(string value, SerializedProperty property) {
            foreach (var target in property.serializedObject.targetObjects) {
                var serializedObject = new SerializedObject(target);
                serializedObject.FindProperty(property.propertyPath).stringValue = value;
                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
        }
    }

}