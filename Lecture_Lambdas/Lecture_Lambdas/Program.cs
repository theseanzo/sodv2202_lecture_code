﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_Lambdas
{
    class Dog
    {
        public string Name { get; set; }
        public bool HypoAllergenic { get; set; }
        public string BarkSound { get; set; }
        public void Bark()
        {

            Console.WriteLine(BarkSound);

        }
    }
    class Program
    {
        //new DogBreed { Name = "Portuguese Water Dog", HypoAllergenic = true},  
        static void Main(string[] args)
        {
            List<Dog> dogBreeds = new List<Dog>() { new Dog { Name = "German Shepard", HypoAllergenic = false }, new Dog { Name = "Shiba Inu", HypoAllergenic = false }, 
                new Dog { Name = "Poodle", HypoAllergenic = true},  new Dog { Name = "Yorkshire Terrier", HypoAllergenic = false }   };
            //using predicates/delegates
           // Func<int, int, int> returnFunction; //<input, input, output>
            //Action<String> printFunction;//always a void function
           // Predicate<int> predicateFunction;//always returns a boolean value
            Dog hypoAllergenic = dogBreeds.Find(FindIfHypoAllergenic);
            //hypoAllergenic = dogBreeds.Find(new delegate (DogBreed dog) { return dog.HypoAllergenic };);
            #region Using lambdas
            //let's try using lambdas to do the same thing!
            hypoAllergenic = dogBreeds.Find(x => x.HypoAllergenic); //note here: the x is not given a variable type; this is inferred by the compiler
            dogBreeds.Add(new Dog { Name = "Portuguese Water Dog", HypoAllergenic = true });
            List<Dog> hypoAllergenicBreeds = dogBreeds.FindAll(x/*says we are passing a value x*/ => /*logic part*/!x.HypoAllergenic);
            //statement lambas
            Action<Dog> announceBreed = dogBreed =>
            {
                Console.WriteLine("Breed name is {0}", dogBreed.Name);
            };
            announceBreed(hypoAllergenic);
            #endregion
            #region Integer Filter
            List<int> values = new List<int>(){ 0, 5, 7, 26, 99, 54, 33, 12, 18, 11, 0, 6, 8, 10 };
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {
                try
                {
                    int filterValue = Int32.Parse(input);
                    List<int> filteredValues = values.FindAll(x => x > filterValue);
                    filteredValues.ForEach(x => { Console.Write("{0} ",x); });// Console.Write);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            #endregion

            #region Events
            DogPack dogPack = new DogPack();
            Dog murtaugh = new Dog() { Name = "Murtaugh", HypoAllergenic = false, BarkSound = "grrr" };
            Dog sparky = new Dog() { Name = "Sparky", HypoAllergenic = false, BarkSound = "WOOF" };
            dogPack.AddDog(murtaugh);
            dogPack.AddDog(sparky);
            #endregion
        }
        static bool FindIfHypoAllergenic(Dog dogBreed)
        {
            return dogBreed.HypoAllergenic;
        }
    }
}