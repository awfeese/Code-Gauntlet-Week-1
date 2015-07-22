// C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe /out:SandwichShop.exe *.cs

public class SandwichShop {
  
  public static void Main(string[] args) {
    
    System.Console.WriteLine("\nSandwich Shop\n");
    
    Sandwich sandwich1 = new Large(new Cheese(new Bacon(new TurkeySandwich())));
    System.Console.WriteLine("Large Cheese, Bacon, and Turkey Sandwich: ${0}",
      string.Format("{0:0.00}", sandwich1.Price));
    
    Sandwich sandwich2 = new Regular(new Avocado(new SauteedOnion(new Cheese(new RoastBeefSandwich()))));
    System.Console.WriteLine("Regular Avocado, Sautéed Onions, Cheese, and Roast Beef Sandwich: ${0}",
      string.Format("{0:0.00}", sandwich2.Price));
      
    System.Console.WriteLine();
  }
}