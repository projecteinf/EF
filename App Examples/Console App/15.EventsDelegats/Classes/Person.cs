class Person {
    public string Nom { get; set; }
    public short NivellIra { get; set; }
    public EventHandler? Shout;  // EventHandler és un delegate => Shout és una propietat delegate

    public Person(string nom, short nivellIra) 
    {
        this.Nom = nom;
        this.NivellIra = nivellIra;
    }
    public void Bufetejar() {
        NivellIra++;
        if (NivellIra>2) {
            if (Shout!=null) {
                this.Shout(this, EventArgs.Empty);
            }
        }
    }
    public void Premiar() {
        NivellIra--;
    }
}