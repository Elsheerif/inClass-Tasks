using System;

abstract class Animal
{
    public string Name { get; }
    public abstract string Sound { get; }

    protected Animal(string name)
    {
        Name = name;
    }

    //(bonus)
    public virtual void Speak()
    {
        Console.WriteLine($"{Name} says: {Sound}");
    }

    public void Sleep()
    {
        Console.WriteLine("ZZZ...");
    }
}

class Dog : Animal
{
    public Dog(string name) : base(name) { }

    public override string Sound => "Woof!";

    public override void Speak()
    {
        base.Speak();
    }
}

class Cat : Animal
{
    public Cat(string name) : base(name) { }

    public override string Sound => "Meow!";

    public override void Speak()
    {
        base.Speak();
    }
}

class Bird : Animal
{
    public Bird(string name) : base(name) { }

    public override string Sound => "Tweet!";

    public override void Speak()
    {
        base.Speak();
    }
}

class Program
{
    static void Main()
    {
        Dog dog = new Dog("Rex");
        Cat cat = new Cat("Luna");
        Bird bird = new Bird("Tweety");

        dog.Speak();
        dog.Sleep();

        cat.Speak();
        cat.Sleep();

        bird.Speak();
        bird.Sleep();
    }
}