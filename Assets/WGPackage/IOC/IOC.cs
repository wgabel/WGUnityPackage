using System;
using System.Collections.Generic;
using UnityEngine;

//https://www.codeproject.com/Articles/347651/Define-Your-Own-IoC-Container
namespace WGPackage.IOC
{
    public static class IOC
    {
        private static Dictionary<Type, Type> types = new Dictionary<Type, Type> ();
        private static Dictionary<Type, object> typeValues = new Dictionary<Type, object> ();

        /// <summary>
        /// Register interface to concrete type without instance(non-singleton)
        /// </summary>
        /// <typeparam name="TContract"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        public static void Register<TContract, TImplementation> ()
            where TImplementation : TContract
        {
            types[typeof ( TContract )] = typeof ( TImplementation );
        }

        /// <summary>
        /// Register type with an instance(singleton).
        /// </summary>
        /// <typeparam name="TContract"></typeparam>
        /// <typeparam name="TImplementation"></typeparam>
        /// <param name="value"></param>
        public static void Register<TContract, TImplementation> ( TImplementation value )
            where TImplementation : TContract
        {
            typeValues[typeof ( TContract )] = value;
        }

        public static object Resolve ( Type type )
        {
            if ( typeValues.ContainsKey ( type ) )
                return typeValues[type];
            if ( types.ContainsKey ( type ) )
            {
                Debug.LogWarning ( "Created instance of a service (" + type + ")" );
                return Activator.CreateInstance ( types[type] );
            }
            throw new ArgumentOutOfRangeException ( "Unregistered Type." );
        }

        public static T Resolve<T> ()
        {
            return (T)Resolve ( typeof ( T ) );
        }
    }
}