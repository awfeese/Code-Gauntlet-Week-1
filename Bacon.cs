public class Bacon : SandwichAddOn {
  public Bacon(Sandwich decoratedSandwich) : base(decoratedSandwich) {
    price = 1.00;
  }
}