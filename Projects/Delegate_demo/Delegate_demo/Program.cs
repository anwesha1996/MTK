using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate_demo
{
    class Program
    {
        public delegate void NewLeadEventHandler(object sender, NewLeadEventArgs e);

        class HR
        {
            public event NewLeadEventHandler NewLead;
           
            protected virtual void OnNewLead(NewLeadEventArgs e)
            {
                if (NewLead != null)
                    NewLead(this, e);
               
            }

            public void EnterLeaderDetails(string name, string sex, int age)
            {
                NewLeadEventArgs e = new NewLeadEventArgs(name, sex, age);
                OnNewLead(e);
            }
            
        }

        class OrchardLead
        {
           
            public OrchardLead(HR hr)
            {
                hr.NewLead += CallHR;
            }

            private void CallHR(object sender, NewLeadEventArgs e)
            {
                Console.WriteLine("Sender of event: " + sender.ToString());
                Console.WriteLine("Orchard Lead Info: " + e.Name +
                                  "," + e.Sex + "," + e.Age.ToString());
                
            }
        }

        static void Main(string[] args)
        {
            HR hr = new HR(); //line1
            OrchardLead cc = new OrchardLead(hr); //line2
            hr.EnterLeaderDetails("Rittik", "male", 26); //line3
            Console.ReadLine(); //line4
            
        }
    }
}
