using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TU_Challenge
{
    /// <summary>
    /// Echauffement avec des fonctions mathématiques
    /// Interdiction d'utiliser Mathf ou Math évidemment
    /// </summary>

    public class Test1_Math
    {
        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(10, 20, 30)]
        [TestCase(-10, 20, 10)]
        [TestCase(10, -20, -10)]
        [TestCase(0, -20, -20)]
        [TestCase(-20, 0, -20)]
        public void Addition(int a, int b, int expected)
        {
            int result = a + b;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, false)]
        [TestCase(12, false)]
        [TestCase(17, false)]
        [TestCase(18, true)]
        [TestCase(40, true)]
        [TestCase(140, true)]
        public void IsMajeur(int age, bool expected)
        {
            bool majeur;

            if (age >= 18)
            {
                majeur = true;
            }
            else
            {
                majeur = false;
            }

            bool result = majeur;
            Assert.IsTrue(result == expected);
        }
        [Test]
        [TestCase(-1)]
        [TestCase(150)]
        public void BreakIsMajeur(int age)
        {
            if (age <= 0 || age >= 120)
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    //age;
                });
            }
        }


        [Test]
        [TestCase(0, true)]
        [TestCase(2, true)]
        [TestCase(10, true)]
        [TestCase(-2, true)]
        [TestCase(1, false)]
        [TestCase(11, false)]
        public void IsEven(int a, bool expected)
        {
            bool even;

            if (a % 2 == 0)
            {
                even = true;
            }
            else
            {
                even = false;
            }
            bool result = even;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 2, true)]
        [TestCase(20, 2, true)]
        [TestCase(3, 2, false)]
        [TestCase(4, 2, true)]
        [TestCase(40, 4, true)]
        [TestCase(123, 3, true)]
        public void IsDivisible(int a, int b, bool expected)
        {
            bool divisible;

            if (a % b == 0)
            {
                divisible = true;
            }
            else
            {
                divisible = false;
            }
            bool result = divisible;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, true)]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(5, true)]
        [TestCase(6, false)]
        [TestCase(7, true)]
        [TestCase(8, false)]
        [TestCase(9, false)]
        [TestCase(10, false)]
        [TestCase(11, true)]
        [TestCase(12, false)]
        [TestCase(13, true)]
        [TestCase(22091, true)]
        [TestCase(22092, false)]
        public void IsPremier(int a, bool expected)
        {
            bool isPrimeNumber;
            int zeroRest = 0;

            for (int i = 0; i < a; i++)
            {
                if (a % i == 0)
                {
                    zeroRest++;
                }
            }

            if (a == 2)
            {
                isPrimeNumber = true;
            }
            else
            {
                isPrimeNumber = false;
            }

            bool result = isPrimeNumber;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 1)]
        [TestCase(20, 8)]
        [TestCase(120, 30)]
        public void GetListPremierList(int a, int countExpected)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < a; i++)
            {
                if (a % i == 0)
                {
                    result.Add(i);
                }
            }

            Assert.That(result.Count, Is.EqualTo(countExpected));
            foreach (var el in result)
            {
                bool isPrimeNumber = false;
                int zeroRest = 0;

                for (int i = 0; i < el; i++)
                {
                    if (el % i == 0)
                    {
                        zeroRest++;
                    }
                }

                if (el == 2)
                {
                    isPrimeNumber = true;
                }
                else
                {
                    isPrimeNumber = false;
                }
                Assert.IsTrue(isPrimeNumber);
            }
        }

        [Test]
        [TestCase(2, 4)]
        [TestCase(8, 64)]
        [TestCase(10, 100)]
        [TestCase(15, 225)]
        public void Power2(int a, int expected)
        {
            int result = a * a;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 2, 4)]
        [TestCase(20, 3, 8000)]
        [TestCase(12, 4, 20736)]
        [TestCase(3, 8, 6561)]
        public void Power(int a, int b, int expected)
        {
            int powerResult = a;
            for (int i = 0; i < b; i++)
            {
                powerResult *= a;
            }

            int result = powerResult;
            Assert.That(result, Is.EqualTo(expected));
        }


        [Test]
        [TestCase(0, 1, 1)]
        [TestCase(0, 10, 1)]
        [TestCase(20, 10, -1)]
        [TestCase(-20, 10, 1)]
        [TestCase(10, 0, -1)]
        [TestCase(20, 20, 0)]
        public void IsInOrder(int a, int b, int expected)
        {
            int ordered;

            if (a < b)
            {
                ordered = 1;
            }
            else if (a == b)
            {
                ordered = 0;
            }
            else
            {
                ordered = -1;
            }

            var result = ordered;
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void TestIsInOrder()
        {
            bool isInOrder = false;
            // Test
            List<int> liste1 = new List<int>() { 12, 0, -1, 123, 45, 90, -123 };
            for (int i = 1; i < liste1.Count; i++)
            {
                if (liste1[i - 1] <= liste1[i])
                {
                    isInOrder = true;
                }
                else
                {
                    isInOrder = false;
                    break;
                }
            }

            bool result = isInOrder;
            Assert.IsFalse(result);

            // Test
            List<int> liste2 = new List<int>() { 0, 12 };
            for (int i = 1; i < liste2.Count; i++)
            {
                if (liste2[i - 1] <= liste2[i])
                {
                    isInOrder = true;
                }
                else
                {
                    isInOrder = false;
                    break;
                }
            }
            result = isInOrder;
            Assert.IsTrue(result);

            // Test
            List<int> liste3 = new List<int>() { 12, 12 };
            for (int i = 1; i < liste3.Count; i++)
            {
                if (liste3[i - 1] <= liste3[i])
                {
                    isInOrder = true;
                }
                else
                {
                    isInOrder = false;
                    break;
                }
            }
            result = isInOrder;
            Assert.IsTrue(result);

            // Test
            List<int> liste4 = new List<int>() { 12 };
            for (int i = 1; i < liste4.Count; i++)
            {
                if (liste4[i - 1] <= liste4[i])
                {
                    isInOrder = true;
                }
                else
                {
                    isInOrder = false;
                    break;
                }
            }
            result = isInOrder;
            Assert.IsTrue(result);

            // Test
            List<int> liste5 = new List<int>() { -123, -1, 0, 12, 45, 90, 123 };
            for (int i = 1; i < liste5.Count; i++)
            {
                if (liste5[i - 1] <= liste5[i])
                {
                    isInOrder = true;
                }
                else
                {
                    isInOrder = false;
                    break;
                }
            }
            result = isInOrder;
            Assert.IsTrue(result);
        }

        // Votre premier algorithme de tri à implémenter.
        // N'hésitez pas à me demander de l'aide sur la partie théorie.
        // Interdiction d'appeller Sort sur la liste.
        [Test]
        public void Sort()
        {
            bool isInOrder = false;
            var toSort = new List<int>() { 12, 0, -1, 123, 45, 90, -123 };
            while (isInOrder == false)
            {
                for (int k = 1; k < toSort.Count; k++)
                {
                    if (toSort[k - 1] <= toSort[k])
                    {
                        toSort.Insert(k, 0);
                        toSort.RemoveAt(k);
                    }
                }

                for (int i = 1; i < toSort.Count; i++)
                {
                    if (toSort[i - 1] <= toSort[i])
                    {
                        isInOrder = true;
                    }
                    else
                    {
                        isInOrder = false;
                        break;
                    }
                }
            }



            var result = toSort;

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i] < result[i + 1]);
            }

        }

        /// <summary>
        /// Test pas obligatoire mais essayez un peu quand même. N'hésitez pas à me demander de l'aide
        /// </summary>
        [Test]
        public void GenericSort()
        {
            var toSort = new List<int>() { 12, 0, -1, 123, 45, 90, -123 };

            var result = MyMathImplementation.GenericSort(toSort, MyMathImplementation.IsInOrder);

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i] < result[i + 1]);
            }
        }
        /// <summary>
        /// Test pas obligatoire mais essayez un peu quand même. N'hésitez pas à me demander de l'aide
        /// </summary>
        [Test]
        public void GenericSortDesc()
        {
            var toSort = new List<int>() { 12, 0, -1, 123, 45, 90, -123 };

            var result = MyMathImplementation.GenericSort(toSort, MyMathImplementation.IsInOrderDesc);

            for (int i = 0; i < result.Count - 1; i++)
            {
                Assert.IsTrue(result[i] > result[i + 1]);
            }
        }

    }
}

