using PicDB.DALs;

namespace PicDB
{
    public class DALFactory
    {
        private static bool mock = false;

        public static void useMock()
        {
            mock = true;
        }

        public static IDAL getDAL()
        {
            if (mock)
            {
                return new MockDAL();
            }
            else
            {
                return new MsSQLDAL();
            }
        }
    }
}
