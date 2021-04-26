using System;
using Treinamento.Classes;
using System.Linq;
using Treinamento.Enum;

namespace Treinamento
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Public/Private Properties
            var customer = new Customer();
            customer.Name = "Cooper";
            customer.Address = "Rua 7 de setembro";
            customer.SetEmail("cooper@gmail.com");
            customer.Activate();

            WriteCustomerOnConsole(customer);
            #endregion

            #region Constructor Properties
            var customerConstructor = new Customer("Luciano", "Rua 2 de setembro", "luciano@gmail.com", false);

            Console.WriteLine("");
            Console.WriteLine("---------Constructor---------");
            WriteCustomerOnConsole(customerConstructor);
            #endregion

            #region Static
            Console.WriteLine("");
            Console.WriteLine("Soma= " + Calculator.Sum(7, 2).ToString());
            Console.WriteLine("Subtração  = " + Calculator.Subtract(7, 2).ToString());

            Console.WriteLine("Multiplicação  = " + Calculator.Multiply(7, 2));
            Console.WriteLine("Divisão = " + Calculator.Division(7, 2).ToString());
            #endregion

            #region Linq
            var products = Product.GenerateNewProducts();
            Console.WriteLine("");
            Console.WriteLine($"Qtd produtos: {products.Count()}");
            Console.WriteLine($"Preço unitário médio: {products.Average(a => a.UnitPrice)}");
            Console.WriteLine($"Maior preço unitário: {products.Max(a => a.UnitPrice)}");
            Console.WriteLine($"Menor preço unitário: {products.Min(a => a.UnitPrice)}");
            Console.WriteLine($"Valor total: {products.Sum(a => a.BoxPrice)}");
            Console.WriteLine($"Primeiro produto: {products.First()}");
            Console.WriteLine($"Último produto: {products.Last()}");
            Console.WriteLine($"Qtd produtos com caixa até 12 unidades: {products.Count(s => s.UnitsPerBox <= 12)}");
            Console.WriteLine($"Códigos dos produtos: {string.Join(", ", products.Select(s => s.Code))}");

            foreach (var product in products)
            {
                switch (product.TypeProduct)
                {
                    case Enum.TypeProduct.Cerveja:
                        break;
                    case Enum.TypeProduct.Refrigenanc:
                        break;
                    case Enum.TypeProduct.DoBem:
                        break;
                    default:
                        break;
                }
            }

            var productsBeer = products.Where(w => w.TypeProduct == Enum.TypeProduct.Cerveja).OrderBy(o => o.Name);
            Console.WriteLine($"Qtd produtos cerveja: {productsBeer.Count()}");

            var firstFiveProductsBeer = productsBeer.Take(5);
            Console.WriteLine($"5 primeiros produtos cerveja: {string.Join(", ", firstFiveProductsBeer.Select(s => s.Name))}");

            var skipFiveProductsBeer = productsBeer.Take(5).Skip(2);
            Console.WriteLine($"3 primeiros produtos cerveja (sem o primeiro e segundo): {string.Join(", ", skipFiveProductsBeer.Select(s => s.Name))}");

            var productsGroupByTypeProduct = products.GroupBy(g => g.TypeProduct)
                            .Select(s => new
                            {
                                TypeProduct = s.Key,
                                TotalBoxPrice = products.Where(w => w.TypeProduct == s.Key).Sum(s => s.BoxPrice)
                            });

            Console.WriteLine($"Total Cerveja: {productsGroupByTypeProduct.First(w => w.TypeProduct == TypeProduct.Cerveja).TotalBoxPrice}");
            Console.WriteLine($"Total Refrigenanc: {productsGroupByTypeProduct.First(w => w.TypeProduct == TypeProduct.Refrigenanc).TotalBoxPrice}");
            Console.WriteLine($"Total DoBem: {productsGroupByTypeProduct.First(w => w.TypeProduct == TypeProduct.DoBem).TotalBoxPrice}");
            #endregion

            Console.ReadKey();
        }

        #region Private Methods

        private static void WriteCustomerOnConsole(Customer customer)
        {
            Console.WriteLine($"ID: {customer.ID}");
            Console.WriteLine($"Name: {customer.Name}");
            Console.WriteLine($"Address: {customer.Address}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Active: {customer.GetActive()}");
        }

        #endregion
    }
}
