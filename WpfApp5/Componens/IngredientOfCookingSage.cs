//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp5.Componens
{
    using System;
    using System.Collections.Generic;
    
    public partial class IngredientOfCookingSage
    {
        public int CookingSageid { get; set; }
        public int IngredientId { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual CookingStage CookingStage { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
