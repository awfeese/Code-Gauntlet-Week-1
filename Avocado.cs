public class Avocado : SandwichAddOn {
  public Avocado(Sandwich decoratedSandwich) : base(decoratedSandwich) { 
    price = 0.25;
  }
}