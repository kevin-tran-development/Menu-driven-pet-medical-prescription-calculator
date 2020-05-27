using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedPortfolio04_KevinTran
{
    public class Pet
    {
        // Declarations
        private string mName;
        private int mAge;
        private double mWeight;
        private char mType;

        // Properties
        public string Name
        {
            get { return mName; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    mName = value;
                }
                else
                {
                    throw new Exception("Name must have at least one non-whitespace character");
                }               
            }
        }

        public int Age
        {
            get { return mAge; }
            set
            {
                if(value >= 1)
                {
                    mAge = value;
                }
                else
                {
                    throw new Exception("Age must be of one or greater value");
                }
            }
        }

        public double Weight
        {
            get { return mWeight; }
            set
            {
                if(value >= 5)
                {
                    mWeight = value;
                }
                else
                {
                    throw new Exception("Weight must be of five or greater value");
                }
            }
        }

        public char Type
        {
            get { return mType; }
            set
            {
                if(value == 'D' || value == 'd')
                {
                    mType = value;
                }
                else if(value == 'C' || value == 'c')
                {
                    mType = value;
                }
                else
                {
                    throw new Exception("Type must be either D for Dog or C for Cat");
                }
            }
        }

        // Constructors
        public Pet(string name, int age, double weight, char type)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Type = type;
        }

        public Pet()
        {
            Name = "Super Pet";
            Age = 1;
            Weight = 5;
            Type = 'D';
        }

        // Methods
        public double Acepromazine()
        {
            double dosage = 0;
            if(mType == 'd' || mType == 'D')
            {
                dosage = (mWeight / 2.205) * (0.03 / 10);
            }
            if(mType == 'c' || mType == 'C')
            {
                dosage = (mWeight / 2.205) * (0.002 / 10);
            }
            return dosage;
        }

        public double Carprofen()
        {
            double dosage = 0;
            if(mType == 'd' || mType == 'D')
            {
                dosage = (mWeight / 2.205) * (0.5 / 12);
            }
            if(mType == 'c' || mType == 'C')
            {
                dosage = (mWeight / 2.205) * (0.25 / 12);
            }
            return dosage;
        }

    }
}
