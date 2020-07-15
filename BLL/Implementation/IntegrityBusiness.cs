namespace BLL.Implementation
{
    using BE;
    using BLL.Interfaces;
    using DAL;
    using DAL.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class IntegrityBusiness : IIntegrityBusiness
    {
        private const string userEntity = "Userdb";
        private const string bitacoraEntity = "Bitacora";

        private readonly IDigitVerifier digitVerifier;
        private readonly IUserDao userDao;
        private readonly IBitacoraDao bitacoraDao;

        public IntegrityBusiness(IDigitVerifier digitVerifier, IUserDao userDao, IBitacoraDao bitacoraDao)
        {
            this.digitVerifier = digitVerifier;
            this.userDao = userDao;
            this.bitacoraDao = bitacoraDao;
        }


        public bool CheckIntegrity(Dictionary<string, int> ids = null)
        {
            var result = false;
            var users = userDao.Get();
            var bitacoras = bitacoraDao.GetBitacora();
            var i = 0;

            foreach (var user in users)
            {
                result = digitVerifier.CheckIntegrity(userEntity, user.GetFinalString(), user.DVH);

                if (!result)
                {
                    ids.Add("UserDb" + i, user.Id);
                    i++;
                }
            }

            foreach (var bitacora in bitacoras)
            {
                result = digitVerifier.CheckIntegrity(bitacoraEntity, bitacora.GetFinalString(), bitacora.DVH);

                if (!result)
                {
                    ids.Add("Bitacora" + i, bitacora.IdLog);
                    i++;
                }
            }

            return result;
        }

        public void UpdateIntegrity()
        {
            var corruptedDvh = new Dictionary<string, int>();
            var users = new List<User>();
            var bitacoras = new List<Bitacora>();

            CheckIntegrity(corruptedDvh);

            if (corruptedDvh.Count > 0)
            {
                var corruptedUsers = corruptedDvh.Keys.Where(x => x.StartsWith("UserDb")).ToList();
                var corruptedBitacoras = corruptedDvh.Keys.Where(x => x.StartsWith("Bitacora")).ToList();

                if (corruptedUsers.Count > 0)
                {
                    var daoUsers = userDao.Get();

                    foreach (var key in corruptedUsers)
                    {
                        users.Add(daoUsers.FirstOrDefault(u => u.Id == corruptedDvh[key]));
                    }

                    foreach (var user in users)
                    {
                        var dvh = digitVerifier.CalculateDVH(user.GetFinalString());
                        digitVerifier.UpdateDvh("UserDb", user.Id, dvh);
                    }
                }

                if (corruptedBitacoras.Count > 0)
                {
                    var daoBitacoras = bitacoraDao.GetBitacora();

                    foreach (var key in corruptedBitacoras)
                    {
                        bitacoras.Add(daoBitacoras.FirstOrDefault(u => u.IdLog == corruptedDvh[key]));
                    }

                    foreach (var bitacora in bitacoras)
                    {
                        var dvh = digitVerifier.CalculateDVH(bitacora.GetFinalString());
                        digitVerifier.UpdateDvh("Bitacora", bitacora.IdLog, dvh);
                    }
                }
            }


            digitVerifier.UpdateDVV(userEntity);
            digitVerifier.UpdateDVV(bitacoraEntity);
        }
    }
}
