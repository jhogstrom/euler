def count_longer_denominator(n):
	res = 0
	p = 1
	q = 2
	for i in range(n):
		qt = q
		q = p + 2 * q
		p = qt
		if len(str(p+q)) > len(str(q)): res += 1
	return res

print count_longer_denominator(1000)

# print len([True for i in range(1000) if calc(i)])

# nom = 0
# for i in range(1000):
# 	p, q = calc(i)
# 	if len(str(p)) > len(str(q)): nom += 1

# print nom