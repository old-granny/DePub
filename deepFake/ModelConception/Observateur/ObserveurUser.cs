using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deepFake.ModelConception.Observateur
{
    public class ObserveurUser
    {
        private List<AbonneUser> ListDabonne = new List<AbonneUser>();

        public void NotifierAbonne()
        {
            foreach (var ob in ListDabonne)
            {
                ob.FaireAction();
            }
        }

        public void AjouterAbonne(AbonneUser user)
        {
            ListDabonne.Add(user);
        }
        public void RetirerAbonne(AbonneUser user) 
        { 
            ListDabonne.Remove(user);
        }

        
    }
}
