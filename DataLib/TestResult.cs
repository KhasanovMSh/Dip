//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class TestResult
    {
        public int Id { get; set; }
        public int Id_student { get; set; }
        public int Id_test { get; set; }
        public int Score { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Test Test { get; set; }
    }
}
