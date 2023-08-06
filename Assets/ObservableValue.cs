public class ObservableValue<T>
    {
        private T value;
        public delegate void ValueChanged(T oldValue, T newValue);
        public event ValueChanged OnValueChanged;

        public void SetValueWithoutNotify(T newValue)
        {
            value = newValue;
        }

        public T Value
        {
            get
            {
                return value;
            }
            set
            {
                var old = this.value;
                if(old.Equals(value))
                {
                    return;
                }
                this.value = value;
                OnValueChanged?.Invoke(old, this.value);
            }
        }
    }