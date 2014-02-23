MAX=1001
# remainders =dict((n, 0) for n in range(3, MAX))
# for a in range(3, MAX):
# 	rmax = 0
# 	for n in range(2, 600):
# 		s = ((a-1)**n)  + ((a+1)**n)
# 		r = s % (a**2)		
# 		if r >  remainders[a]: remainders[a] = r
# 	print a, a**2, "=>", remainders[a], a * (a-1), 	remainders[a]- a * (a-1)

# print sum(remainders.values())
print sum(n*(n-1) for n in range(3, MAX)) - sum(n for n in range(4, MAX)[::2])

