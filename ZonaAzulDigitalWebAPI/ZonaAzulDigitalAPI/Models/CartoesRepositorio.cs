using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZonaAzulDigitalAPI.Models
{
    public class CartoesRepositorio : ICartoesRepositorio
    {
        private List<Cartoes> _cartoes;

        public CartoesRepositorio()
        {
            InicializaDados();
        }

        private void InicializaDados()
        {
            _cartoes = DalHelper.GetCartoes();
        }

        public IEnumerable<Cartoes> All
        {
            get { return _cartoes; }
        }

        public void Delete(int Cd_Cartoes)
        {
            //DalHelper.DeleteCartoes(Cd_Cartoes);
        }

        public Cartoes Find(int Cd_Cartoes)
        {
            return DalHelper.GetCartoes(Cd_Cartoes);
        }

        public void Insert(Cartoes cartoes)
        {
            if (cartoes == null)
            {
                throw new ArgumentNullException("cartoes");
            }

            DalHelper.InsertCartoes(cartoes);
        }

        public void Update(Cartoes cartoes)
        {
            if (cartoes == null)
            {
                throw new ArgumentNullException("cartoes");
            }

            DalHelper.UpdateCartoes(cartoes);
        }
    }
}