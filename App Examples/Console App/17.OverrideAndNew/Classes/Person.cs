public class Persona {
    public string Name { get; set; }
    public Persona(string name) {
        this.Name = name;
    }

    // Signatura ToString de la classe Object: public virtual string? ToString();
    public override string ToString() {
        return $"Override ToString() of class Object {this.Name}";
    }
    public virtual string? ToStringNew() {
        return $"ToStringNew() of class Persona {this.Name}";
    }
}