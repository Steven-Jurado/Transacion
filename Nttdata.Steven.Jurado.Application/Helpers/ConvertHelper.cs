namespace Nttdata.Steven.Jurado.Application.Helpers
{
    using Newtonsoft.Json;

    public class ConvertHelper
    {
        public static T ConvertType<T>(object type) where T : class
        {

            var objectString = JsonConvert.SerializeObject(type);
            var newObject = JsonConvert.DeserializeObject<T>(objectString);

            return newObject;
        }
    }
}
