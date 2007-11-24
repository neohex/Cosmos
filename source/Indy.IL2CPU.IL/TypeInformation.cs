﻿using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace Indy.IL2CPU.IL {
	// TODO: abstract this one out to a X86 specific one
	public class TypeInformation {
		public struct Field {
			public readonly int Offset;

			/// <summary>
			/// Contains the relative address. This should be used as follows:
			/// <example>new Push("[eax " + theField.RelativeAddress + "]");</example>
			/// </summary>
			public readonly string RelativeAddress;

			public readonly int Size;

			public readonly bool NeedsGC;
			public readonly TypeReference FieldType;

			public Field(int aOffset, int aSize, bool aNeedsGC, TypeReference aFieldType) {
				Offset = aOffset;
				NeedsGC = aNeedsGC;
				FieldType = aFieldType;
				Size = aSize;
				RelativeAddress = "+ 0" + (Offset).ToString("X") + "h";
			}

			public override string ToString() {
				return String.Format("{0}\t{1}\t{2}", Offset, Size, RelativeAddress);
			}
		}

		public readonly SortedList<string, Field> Fields;
		public readonly int StorageSize;
		public readonly TypeDefinition TypeDef;
		public readonly bool NeedsGC;
		public TypeInformation(int aStorageSize, SortedList<string, Field> aFields, TypeDefinition aTypeDef, bool aNeedsGC) {
			Fields = aFields;
			StorageSize = aStorageSize;
			TypeDef = aTypeDef;
			NeedsGC = aNeedsGC;
		}
	}
}