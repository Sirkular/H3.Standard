﻿/*
 * Copyright 2022, Swail, Arnaud Ménard
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *         http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using System.Runtime.InteropServices;

namespace H3Standard.Tests
{
	[TestClass]
	public class UnitTest_07_Vertex
	{
        [TestMethod]
        public void TestCellToVertex()
        {
            ulong origin = 621923649824456703;
            int vertexNum = 1;
            ulong vertex = 0;
            var error = H3.cellToVertex(origin, vertexNum, ref vertex);

        }

        [TestMethod]
        public void TestCellToVertexes()
        {
            ulong origin = 621923649824456703;
            ulong[] vertices = new ulong[3];
            var error = H3.cellToVertexes(origin, vertices);
            Assert.AreEqual(vertices[0], (UInt64)2639536282883522559);
        }

        [TestMethod]
        public void TestVertexToLatLng()
        {
            ulong origin = 621923649824456703;
            LatLng latLng = new LatLng();
            var error = H3.vertexToLatLng(origin, ref latLng);
            Assert.AreEqual(latLng.LatWGS84 - 47.70063269164244 < UnitTest.DoubleTolerance, true);
            Assert.AreEqual(latLng.LngWGS84 + 3.0002084452356717 < UnitTest.DoubleTolerance, true);
        }

        [TestMethod]
        public void TestIsValidVertex()
        {
            ulong vertex = 2639536282883522559;
            var result = H3.isValidVertex(vertex);
            Assert.AreEqual(result, 1);
        }

    }
}

