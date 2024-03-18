namespace Module.Utils
{
    public class Converter
    {
        public static Dictionary<string, dynamic> ConvertToDictionary(object obj)
        {
            if(obj == null) return new Dictionary<string, dynamic> ();

            var properties = obj.GetType().GetProperties();

            Dictionary<string, dynamic> dictionary = new Dictionary<string, dynamic>();

            foreach (var property in properties)
            {
                Type propertyType = property.PropertyType;
                dynamic value = property.GetValue(obj);
                
                if (value is String || value is Int64 || value is Boolean)
                {
                    dictionary.Add(property.Name, value);
                }
                else
                {
                    if (value == null) Console.WriteLine(property.Name);

					var dict = Converter.ConvertToDictionary(value);
                    
                    foreach (KeyValuePair<string, dynamic> pair in dict)
                    {
                        dictionary.Add($"{property.Name}_{pair.Key}", pair.Value);
					}
                }
            }
            return dictionary;
        }
    }
}