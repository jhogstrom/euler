from decimal import *
getcontext().prec = 2000
longest = 0
for i in range(1, 1000):
	d = str(Decimal(1)/Decimal(i))
	if len(d) < 100:
		continue
	sub = d[10:20]
	p = d.find(sub, 11)
	#print p, i, sub, len(d)
	if p > longest:
		longest, n = p, i

print n, longest



