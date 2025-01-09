using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace WarehouseManagement
{
    class Program
    {
        //Lists and objects for storing inputs
        static List<Category> categoryList = new List<Category>();
        static List<Product> productList = new List<Product>();
        static List<Warehouse> warehouseList = new List<Warehouse>();
        static List<Transaction> transactionList = new List<Transaction>();

        static void Main(string[] args)
        {
            while (true)
            {   // Show & Print List of Warehouse App in Console
                //Console.Clear();
                string? textShow = "Warehouse Management App";

                Console.WriteLine(new string('*', textShow.Length + 4));
                Console.WriteLine($"* {textShow} *");
                Console.WriteLine(new string('*', textShow.Length + 4));
                // Console.WriteLine("ـــــ Please Choose Your Category: ـــــ\r\n");

                Console.WriteLine("1. Define Categories");
                Console.WriteLine("2. Define Products");
                Console.WriteLine("3. Define Warehouses");
                Console.WriteLine("4. Display Warehouse List");
                Console.WriteLine("5. Register Incoming Products");
                Console.WriteLine("6. Register Outgoing Products");
                Console.WriteLine("7. Display Inventory");
                Console.WriteLine("8. Exit Application\n");

                Console.Write("Select an option: ");

                int input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        DefineProductCategories();
                        break;
                    case 2:
                        DefineProducts();
                        break;
                    case 3:
                        DefineWarehouses();
                        break;
                    case 4:
                        DisplayWarehouseList();
                        break;
                    case 5:
                        RegisterIncomingProducts();
                        break;
                    case 6:
                        RegisterOutgoingProducts();
                        break;
                    case 7:
                        DisplayInventory();
                        break;
                    case 8:
                        Console.WriteLine("Exiting application...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void DefineProductCategories()
        {
            Console.Write("Enter Category Name: ");
            string categoryNameInput = Console.ReadLine();
            Console.Write("Enter Category Code: ");
            string categoryCodeInput = Console.ReadLine();
            Category referenceToCategory = new Category() { CategoryName = categoryNameInput, CategoryCode = categoryCodeInput };
            //categoryList.Add(new Category (){ CategoryName = categoryNameInput, CategoryCode = categoryCodeInput });
            categoryList.Add(referenceToCategory);

            Console.WriteLine("Category added successfully.\n");
        }

        static void DefineProducts()
        {
            Console.Write("Enter Product Name: ");
            string productNameInput = Console.ReadLine();
            Console.Write("Enter Product Code: ");
            string productCodeInput = Console.ReadLine();
            Console.Write("Enter Category Code: ");
            string productCategoryCodeInput = Console.ReadLine();
            Console.Write("Enter Price: ");
            decimal productPriceInput = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Quantity: ");
            int productQuantityInput = int.Parse(Console.ReadLine());

            Product referenceToProduct = new Product()
            {
                ProductName = productNameInput, ProductCode = productCodeInput,
                ProductCategoryCode = productCategoryCodeInput, ProductPrice = productPriceInput,
                ProductQuantity = productQuantityInput
            };
            productList.Add(referenceToProduct);
            /*productList.Add(new Product
            {
                ProductName = productNameInput,
                ProductCode = productCodeInput,
                ProductCategoryCode = productCategoryCodeInput,
                ProductPrice = productPriceInput,
                ProductQuantity = productQuantityInput
            });*/
            Console.WriteLine("Product added successfully.\n");
        }

        static void DefineWarehouses()
        {
            Console.Write("Enter Warehouse Name: ");
            string warehouseNameInput = Console.ReadLine();
            Console.Write("Enter Warehouse Code: ");
            string warehouseCodeInput = Console.ReadLine();

            Warehouse referenceToWarehouse = new Warehouse()
                { WarehouseName = warehouseNameInput, WarehouseCode = warehouseCodeInput };
            warehouseList.Add(referenceToWarehouse);
            /*warehouseList.Add(new Warehouse { WarehouseName = warehouseNameInput, WarehouseCode = warehouseCodeInput });*/
            Console.WriteLine("Warehouse added successfully.\n");
        }

        static void DisplayWarehouseList()
        {
            Console.WriteLine("\nWarehouse List:");
            foreach (var warehouse in warehouseList)
            {
                Console.WriteLine($"\nWarehouse Name: {warehouse.WarehouseName}, Warehouse Code: {warehouse.WarehouseCode}");
                foreach (var product in productList)
                {
                    var category = categoryList.FirstOrDefault(c => c.CategoryCode == product.ProductCategoryCode);
                    Console.WriteLine($"Product Code: {product.ProductCode}, Category Name: {category?.CategoryName}, Category Code: {product.ProductCategoryCode}, Price: {product.ProductPrice}\n");
                }
            }
        }

        static void RegisterIncomingProducts()
        {
            Console.Write("Enter Product Code: ");
            string incomingProductCodeInput = Console.ReadLine();
            Console.Write("Enter Warehouse Code: ");
            string incomingWarehouseCodeInput = Console.ReadLine();
            /*Console.Write("Enter Entry Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime incomingEntryDateInput))
            {
                Console.WriteLine("Invalid date format. Please enter in yyyy-MM-dd format.");
                return;
            }*/
            DateTime incomingEntryDateInput;
            Console.Write("Enter Entry Date (yyyy-MM-dd): ");

            try
            {
                incomingEntryDateInput = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please enter in yyyy-MM-dd format.");
                return;
            }


            Console.Write("Enter Operator Name: ");
            string incomingOperatorNameInput = Console.ReadLine();
            Transaction referenceToTransaction = new Transaction()
            {
                TransactionProductCode = incomingProductCodeInput,
                TransactionWarehouseCode = incomingWarehouseCodeInput,
                TransactionEntryDate = incomingEntryDateInput,
                TransactionOperatorName = incomingOperatorNameInput,
                TransactionType = TransactionType.Incoming
            };
            transactionList.Add(referenceToTransaction);


            /*transactionList.Add(new Transaction
            {
                TransactionProductCode = incomingProductCodeInput,
                TransactionWarehouseCode = incomingWarehouseCodeInput,
                TransactionEntryDate = incomingEntryDateInput,
                TransactionOperatorName = incomingOperatorNameInput,
                TransactionType = TransactionType.Incoming
            });*/

            Console.WriteLine("Incoming product registered successfully.\n");
        }

        static void RegisterOutgoingProducts()
        {
            Console.Write("Enter Product Code: ");
            string outgoingProductCodeInput = Console.ReadLine();
            Console.Write("Enter Warehouse Code: ");
            string outgoingWarehouseCodeInput = Console.ReadLine();
            /*Console.Write("Enter Exit Date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime outgoingExitDateInput))
            {
                Console.WriteLine("Invalid date format. Please enter in yyyy-MM-dd format.");
                return;
            }*/
            DateTime outgoingExitDateInput;
            Console.Write("Enter Entry Date (yyyy-MM-dd): ");

            try
            {
                outgoingExitDateInput = DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please enter in yyyy-MM-dd format.");
                return;
            }

            Console.Write("Enter Operator Name: ");
            string outgoingOperatorNameInput = Console.ReadLine();



            transactionList.Add(new Transaction
            {
                TransactionProductCode = outgoingProductCodeInput,
                TransactionWarehouseCode = outgoingWarehouseCodeInput,
                TransactionExitDate = outgoingExitDateInput,
                TransactionOperatorName = outgoingOperatorNameInput,
                TransactionType = TransactionType.Outgoing
            });

            Console.WriteLine("Outgoing product registered successfully.\n");
        }

        static void DisplayInventory()
        {
            Console.WriteLine("\nInventory:");

            foreach (var warehouse in warehouseList)
            {
                Console.WriteLine($"Warehouse Name: {warehouse.WarehouseName}, Warehouse Code: {warehouse.WarehouseCode}");
                foreach (var product in productList)
                {
                    int incomingCount = 0;
                    int outgoingCount = 0;
                    foreach (var transaction in transactionList)
                    {
                        if (transaction.TransactionProductCode == product.ProductCode && transaction.TransactionWarehouseCode == warehouse.WarehouseCode)
                        {
                            if (transaction.TransactionType == TransactionType.Incoming)
                                incomingCount++;
                            else if (transaction.TransactionType == TransactionType.Outgoing)
                                outgoingCount++;
                        }
                    }


                    if (incomingCount > 0 || outgoingCount > 0)
                    {
                        int remainingCount = incomingCount - outgoingCount;
                        Console.WriteLine($"Product Name: {product.ProductName}, Product Code: {product.ProductCode}, Incoming: {incomingCount}, Outgoing: {outgoingCount}, Remaining: {remainingCount}\n");

                    }


                }
            }
        }
    }
}