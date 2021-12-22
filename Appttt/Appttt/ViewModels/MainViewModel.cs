using System;
using System.Collections.Generic;
using System.Text;

namespace Appttt.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Onboardings = GetOnboarding();
        }
        public List<Onboarding> Onboardings { get; set; }
        private List<Onboarding> GetOnboarding()
        {
            return new List<Onboarding>
            {
                new Onboarding { Heading = "Welcome to Virtual Tourist", Caption = "Visit Flevoland on your bike in three rounds in your own environment. That is possible, and we simply do it virtually."},
                new Onboarding { Heading = "What is the virtual bike ride?", Caption = "A virtual challenge is simply a journey that we have set out in an environment and that we can experience from home. You can cycle or walk our tour outside or inside, in your own environment."},
                new Onboarding { Heading = "How does it work?", Caption = "1. Choose a virtual bike ride and sign up\n2. Do you cycle for miles outside or inside\n3. Register your rides with Strava\n4. Upload your trips in kilometers on our site"},
                new Onboarding { Heading = "How does it work?", Caption = "5. See how far you are (possibly if you cycle together in a team)\n6. Experience your journey through personal emails with stories and great offers\n7. Decide for yourself in how many trips you will cover the 150-kilometre route. On each ride there are about 15 to 20 pearls that you visit"},
                new Onboarding { Heading = "How does it work?", Caption = "8. Receive your earned reward when you finish.\n\n\nDo you have what it takes?"},
            };
        }
    }
    public class Onboarding
    {
        public string Heading { get; set; }
        public string Caption { get; set; }
    }
}
