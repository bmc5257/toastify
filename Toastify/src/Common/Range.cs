﻿using System;
using System.Collections.Generic;

namespace Toastify.Common
{
    public struct Range<T> : IEquatable<Range<T>> where T : IComparable
    {
        #region Public Properties

        public T Min { get; }
        public T Max { get; }

        #endregion

        public Range(T min, T max)
        {
            this.Min = min;
            this.Max = max;
        }

        public bool Contains(T value)
        {
            return value.CompareTo(this.Min) >= 0 && value.CompareTo(this.Max) <= 0;
        }

        #region Equals / GetHashCode

        /// <inheritdoc />
        public bool Equals(Range<T> other)
        {
            return EqualityComparer<T>.Default.Equals(this.Min, other.Min) &&
                   EqualityComparer<T>.Default.Equals(this.Max, other.Max);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            return obj is Range<T> range && this.Equals(range);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(this.Min) * 397) ^ EqualityComparer<T>.Default.GetHashCode(this.Max);
            }
        }

        #endregion Equals / GetHashCode
    }
}