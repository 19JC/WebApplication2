//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class books
    {
        public int ISBN_INT { get; set; }
        public Nullable<int> editorials_id { get; set; }
        public string title { get; set; }
        public string synopsis { get; set; }
        public string n_pages { get; set; }
    
        public virtual authors_has_books authors_has_books { get; set; }
        public virtual editorials editorials { get; set; }
    }
}
