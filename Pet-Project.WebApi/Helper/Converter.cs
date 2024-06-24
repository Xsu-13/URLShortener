using System.Text;

namespace Pet_Project.WebApi.Helper
{
    public static class Converter
    {
        private const string Base62Characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public async static Task<string> ConvertToBase62(Guid value)
        {
            StringBuilder sb = new StringBuilder();

            byte[] bytes = value.ToByteArray();

            long longValue = BitConverter.ToInt64(bytes, 0);

            while (longValue > 0)
            {
                int remainder = (int)(longValue % 62);
                sb.Insert(0, Base62Characters[remainder]);
                longValue /= 62;
            }

            return sb.ToString();
        }
    }
}
