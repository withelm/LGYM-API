using System.ComponentModel;

namespace Lgym.Resources.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private readonly Type _resourceType;
        private readonly string _resourceKey;

        private bool _isValueLoaded = false;

        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType) :
            base(resourceKey)
        {
            _resourceType = resourceType;
            _resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                if (!_isValueLoaded)
                {
                    var property = _resourceType.GetProperty(_resourceKey,
                            System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic
                        );
                    if (property != null)
                    {
                        var val = property.GetValue(null, null) as string;
                        if (!string.IsNullOrEmpty(val))
                        {
                            base.DescriptionValue = val;
                        }
                    }
                    _isValueLoaded = true;
                }
                return base.DescriptionValue;
            }
        }
    }
