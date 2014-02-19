import itertools
import string

def makeint(t):
	return int("".join([str(i) for i in t]))

product = set()
for s in itertools.permutations([1, 2, 3, 4, 5, 6, 7, 8, 9]):
	for x in range(7):
		for e in range(7-x):
			m1 = makeint(s[:x + 1])
			m2 = makeint(s[x+1:x+e+2])
			p = makeint(s[x+e+2:])
			if m1 * m2 == p:
				product.add(p)

print sum(product)
