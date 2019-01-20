using System;
using System.Collections.Generic;
using UnityEngine;

namespace WGPackage.IOC
{
    public static class IOC
    {
        private static Dictionary<Type, Type> types = new Dictionary<Type, Type> ();
        private static Dictionary<Type, object> typeValues = new Dictionary<Type, object> ();

        public static void Register<TContract, TImplementation> ()
            where TImplementation : TContract
        {
            types[typeof ( TContract )] = typeof ( TImplementation );
        }

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