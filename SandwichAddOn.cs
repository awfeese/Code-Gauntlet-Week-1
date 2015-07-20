public abstract class SandwichAddOn : Sandwich {
  protected Sandwich decoratedSandwich;
  protected double price;
  
  public SandwichAddOn(Sandwich decoratedSandwich) {
    this.decoratedSandwich = decoratedSandwich;
  }
  
  public double Price {
    get {
      return price + decoratedSandwich.Price;
    }
  }
}