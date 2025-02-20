class Treballador : Persona {
    public string NSS {get; set;}
    public Treballador(string name,string nss) : base(name) { // Crida al constructor pare (Persona)
        this.NSS = nss;
    }
    public override string ToString() {
        return $"Override ToString() of class Persona {this.NSS}";
    }

    public new string? ToStringNew() {
        return $"ToStringNew() of class Treballador {this.NSS}";
    }
}