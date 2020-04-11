using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ExamTwoCodeQuestions.Data
{
    public class Cobbler : IOrderItem, INotifyPropertyChanged
    {

        /// <summary>
        /// Event for property changed with a clicked button
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The fruit used in the cobbler
        /// </summary>
        public FruitFilling Fruit { get; set; }

        private bool withIceCream = true;

        /// <summary>
        /// If the cobbler is served with ice cream
        /// </summary>
        public bool WithIceCream
        {
            get
            {
                return withIceCream;
            }
            set 
            {
                withIceCream = value;
                NotifyPropertyChanged("WithIceCream");
                NotifyPropertyChanged("SpecialInstructions");
            }
        }
        /// <summary>
        /// Gets the price of the Cobbler
        /// </summary>
        public double Price
        {
            get
            {
                if (WithIceCream) return 5.32;
                else return 4.25;
            }
        }

        /// <summary>
        /// Gets any special instructions for preparing this dessert
        /// </summary>
        public List<string> SpecialInstructions
        {
            get
            {
                ///if(WithIceCream) { return new List<string>(); }
                ///else { return new List<string>() { "Hold Ice Cream" };}
                var instruction = new List<string>();

                if (!WithIceCream) instruction.Add("Hold Ice Cream");

                return instruction;
            }
        }

        /// <summary>
        /// Notifys our special instructions of the change made
        /// </summary>
        public void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SpecialInstructions"));
        }

    }
}
