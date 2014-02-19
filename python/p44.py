import itertools
import math
def pent(n):
	return n * ( 3 * n - 1 ) / 2

pents = dict([(i,pent(i)) for i in range(1, 100) ])

i = 0
for p in itertools.permutations(pents.items(),2):
	print p
	i += 1
	if abs(p[0][1] - p[1][1]) in pents.values() and p[0][1] + p[1][1] in pents.values():
		print "diff: ", p, abs(p[0][1] - p[1][1])
	if not i % 1000:
		print i
