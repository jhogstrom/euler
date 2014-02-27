import itertools
import math
def pent(n):
	return n * ( 3 * n - 1 ) / 2

def ispent(n):
	f = (.5 + math.sqrt(.25+6*n))/3
   	return f - int(f) == 0

i = 2
while True:
	pi = pent(i)
	j = 1
	while j < i:
		pj = pent(j)
		if ispent(pi-pj) and ispent(pi+pj): 
			print "Answer:", pi-pj
			exit()
		j += 1
	i += 1

pents = dict([(i,pent(i)) for i in range(1, 10000) ])
i = 0
for p in itertools.permutations(pents.items(),2):
	# print p
	i += 1
	if abs(p[0][1] - p[1][1]) in pents.values() and p[0][1] + p[1][1] in pents.values():
		print "diff: ", p, abs(p[0][1] - p[1][1])
	# if not i % 1000:
	# 	print i
