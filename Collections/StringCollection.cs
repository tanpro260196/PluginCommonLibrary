﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace Terraria.Plugins.Common.Collections {
  public class StringCollection: Collection<string> {
    public StringCollection() {}

    public StringCollection(IList<string> wrappedList): base(wrappedList) {}

    public int IndexOf(string item, StringComparison comparison) {
      if (comparison == StringComparison.InvariantCulture)
        return base.IndexOf(item);

      for (int i = 0; i < this.Items.Count; i++) {
        if (this.Items[i].Equals(item, comparison))
          return i;
      }

      return -1;
    }

    public bool Contains(string item, StringComparison comparison) {
      return (this.IndexOf(item, comparison) > -1);
    }

    public void Remove(string item, StringComparison comparison) {
      int itemIndex = this.IndexOf(item, comparison);
      if (itemIndex == -1)
        throw new ArgumentException("The item does not exist.");

      this.RemoveAt(itemIndex);
    }

    public override string ToString() {
      return string.Join(", ", this.Items);
    }
  }
}
