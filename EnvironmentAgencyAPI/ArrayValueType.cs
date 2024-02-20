namespace EnvironmentAgencyAPI
{
    public struct ArrayValueType<T>
    {
        public IReadOnlyList<T> Values { get; }

        public T Value => Values.FirstOrDefault()!;

        public ArrayValueType(T value)
        {
            Values = new List<T> { value };
        }

        public ArrayValueType(IEnumerable<T> values)
        {
            if (values.Count() < 1)
            {
                throw new ArgumentException("The collection must contain at least 1 value");
            }
            Values = values.ToList();
        }

        public static implicit operator T(ArrayValueType<T> value)
        {
            return value.Values[0];
        }

        public static implicit operator ArrayValueType<T>(T value)
        {
            return new ArrayValueType<T>(value);
        }

        public static implicit operator ArrayValueType<T>(List<T> values)
        {
            return new ArrayValueType<T>(values);
        }

        public static bool operator == (ArrayValueType<T> arrayValueType, ArrayValueType<T> value)
        {
            if(arrayValueType.Values == null)
            {
                return false;
            }
            if(value.Values == null)
            {
                return false;
            }
            foreach(var v in arrayValueType.Values)
            {
                foreach(var v2 in value.Values)
                {
                    if(v?.Equals(v2) ?? false)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator !=(ArrayValueType<T> arrayValueType, ArrayValueType<T> value)
        {
            if(arrayValueType.Values == null)
            {
                return false;
            }
            if(value.Values == null)
            {
                return false;
            }

            foreach(var v in arrayValueType.Values)
            {
                foreach(var v2 in value.Values)
                {
                    if(v?.Equals(v2) ?? false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
