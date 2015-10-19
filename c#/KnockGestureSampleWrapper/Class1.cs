using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using VL.Core;
using VL.Lib.Collections;

namespace KnockGestureSampleWrapper
{
    [Type]
    public class KnockGestureSampleHelper
    {
        //Workaround: I can't import Buffer from Rx, for a reason I don't understand
        //probably has to do with the fact that there is an IList in the return value, but I also tried to import IList
        [Node]
        public static IObservable<Spread<TSource>> Buffer<TSource>(IObservable<TSource> source, Int32 count, Int32 skip)
        {
            IObservable<Spread<TSource>> result;
            if (skip > 0)
                result = Observable.Buffer(source, count, skip).Select(input => input.ToSpread<TSource>());
            else result = Observable.Empty<Spread<TSource>>();
            return result;
        }

        [Node]
        public static bool foo() { return false; }
    }
}