using Responders;

namespace Usecases
{
    public class InitialResponse : IInitialResponse
    {
        private double mean1stMomment;
        private double mean2ndtMomment;
        private double mean3rdMomment;
        private double mean4thMomment;
        private double n2;
        private double n3;
        private double n4;
        private double b1;
        private double b2;
        private double w;
        private double beta1;
        private double beta2;
        private string johnsonType;

        public double Mean1stMomment { get => mean1stMomment; set => mean1stMomment = value; }
        public double Mean2ndtMomment { get => mean2ndtMomment; set => mean2ndtMomment = value; }
        public double Mean3rdMomment { get => mean3rdMomment; set => mean3rdMomment = value; }
        public double Mean4thMomment { get => mean4thMomment; set => mean4thMomment = value; }
        public double N2 { get => n2; set => n2 = value; }
        public double N3 { get => n3; set => n3 = value; }
        public double N4 { get => n4; set => n4 = value; }
        public double B1 { get => b1; set => b1 = value; }
        public double B2 { get => b2; set => b2 = value; }
        public double W { get => w; set => w = value; }
        public double Beta1 { get => beta1; set => beta1 = value; }
        public double Beta2 { get => beta2; set => beta2 = value; }
        public string JohnsonType { get => johnsonType; set => johnsonType = value; }
    }
}