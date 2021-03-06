using System;
using System.Collections.Generic;
using System.Globalization;

namespace SiliconStudio.Xenko.Updater
{
    /// <summary>
    /// Resolver for <see cref="IList{T}"/> in property path.
    /// </summary>
    /// <typeparam name="T">The type of list items.</typeparam>
    public class ListUpdateResolver<T> : UpdateMemberResolver
    {
        public override Type SupportedType => typeof(IList<T>);

        /// <inheritdoc/>
        public override UpdatableMember ResolveIndexer(string indexerName)
        {
            // Transform index into integer
            int indexerValue;
            if (!int.TryParse(indexerName, NumberStyles.Any, CultureInfo.InvariantCulture, out indexerValue))
                throw new InvalidOperationException(string.Format("Property path parse error: could not parse indexer value '{0}'", indexerName));

            return new UpdatableListAccessor<T>(indexerValue);
        }
    }
}