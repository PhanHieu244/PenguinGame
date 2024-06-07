namespace ChuongCustom
{ 
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using UnityEditor;
    using UnityEditor.IMGUI.Controls;
    using UnityEngine;

    public class IAPDropDownPopup : AdvancedDropdown {
        public static readonly Dictionary<string, string> CATALOG = MakeCatalog((key, _) => Nicky(key), (_, value) => value);
        public static readonly Dictionary<string, string> INVERSE_CATALOG = MakeCatalog((_, value) => value, (key, _) => Nicky(key));
        private static readonly Dictionary<string, string> IAP_TYPE = MakeCatalog((key, _) => Nicky(key), (key, _) => Prefix(key));

        private static readonly float k_HeaderHeight = EditorGUIUtility.singleLineHeight * 2f;
        public Action<string> OnItemSelected;

        public IAPDropDownPopup(AdvancedDropdownState state, int maxLineCount) : base(state) {
            minimumSize = new Vector2(minimumSize.x, EditorGUIUtility.singleLineHeight * maxLineCount + k_HeaderHeight);
        }

        protected override AdvancedDropdownItem BuildRoot() {
            var root = new AdvancedDropdownItem("select product id");
            var count = 0;
            root.AddChild(AddEmpty(ref count));
            root.AddChild(AddMenu("c", "consumable", ref count));
            root.AddChild(AddMenu("nc", "non-consumable", ref count));
            root.AddChild(AddMenu("s", "subscription", ref count));
            return root;
        }

        private static AdvancedDropdownItem AddEmpty(ref int count) {
            return new IAPAdvancedDropdownItem("empty", "empty")
            {
                id = count++
            };
        }

        private static AdvancedDropdownItem AddMenu(string shortcut, string name, ref int count) {
            var root = new AdvancedDropdownItem(name);
            foreach (var (key, value) in CATALOG) {
                if (IAP_TYPE[key] == shortcut) {
                    root.AddChild(new IAPAdvancedDropdownItem(key, key)
                    {
                        id = count++
                    });
                }
            }

            return root;
        }

        protected override void ItemSelected(AdvancedDropdownItem item) {
            base.ItemSelected(item);
            if (item is IAPAdvancedDropdownItem iapItem) {
                OnItemSelected?.Invoke(CATALOG[iapItem.key]);
            }
        }

        private static Dictionary<string, string> MakeCatalog(Func<string, string, string> key, Func<string, string, string> value) {
            var type = typeof(IAPKey);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            var dictionary = new Dictionary<string, string>
            {
                { key("empty", string.Empty), value("empty", string.Empty) }
            };

            foreach (var field in fields) {
                var fieldValue = field.GetValue(null).ToString();
                var fieldName = MakeName(field.Name);
                dictionary.Add(key(fieldName, fieldValue), value(fieldName, fieldValue));
            }

            return dictionary;
        }

        private static string MakeName(string name) {
            return name.Replace("_", " ").ToLower();
        }

        private class IAPAdvancedDropdownItem : AdvancedDropdownItem {
            public readonly string key;

            public IAPAdvancedDropdownItem(string name, string key) : base(name) {
                this.key = key;
            }
        }

        private static string Prefix(string name) {
            if (name.StartsWith("c")) {
                return "c";
            }

            if (name.StartsWith("nc")) {
                return "nc";
            }

            return name.StartsWith("s") ? "s" : string.Empty;
        }

        private static string Nicky(string name) {
            if (name.StartsWith("c")) {
                return name[2..];
            }

            if (name.StartsWith("nc")) {
                return name[3..];
            }

            return name.StartsWith("s") ? name[2..] : name;
        }
    }
}