using System;
using System.Runtime.CompilerServices;

namespace KnockoutApi
{
    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public abstract class KnockoutMappingPropertySpecification
    {
        protected KnockoutMappingPropertySpecification()
        {
        }
    }

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public class KnockoutMappingPropertySpecification<TModel> : KnockoutMappingPropertySpecification
    {
        [IntrinsicProperty]
        public Func<MappingCreateOptions, TModel> Create
        {
            get
            {
                Func<MappingCreateOptions, TModel> func = null;
                return func;
            }
            set
            {
            }
        }

        [IntrinsicProperty]
        public Func<MappingUpdateOptions, TModel> Update
        {
            get
            {
                Func<MappingUpdateOptions, TModel> func = null;
                return func;
            }
            set
            {
            }
        }

    }

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public class MappingCreateOptions
    {
        [IntrinsicProperty]
        public object Data
        {
            get;
            set;
        }

        [IntrinsicProperty]
        public object Parent
        {
            get;
            set;
        }
    }

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public class MappingUpdateOptions
    {
        [IntrinsicProperty]
        public object Data
        {
            get;
            set;
        }

        [IntrinsicProperty]
        public object Observable
        {
            get;
            set;
        }

        [IntrinsicProperty]
        public object Parent
        {
            get;
            set;
        }
    }
}
