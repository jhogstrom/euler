import string

_fact = {0:1, 1:1}
def fact(n):
	#print "fact(", n, ")"
	if _fact.has_key(n):
		#print "cache hit:", n
		return _fact[n]
	if n == 1 or n == 0:		
		return 1
	f = fact(n-1)
	#print "inserting", f, "in cache", n-1
	_fact[n-1] = f
	return n * f

_f = {}
def f(n):
	if _f.has_key(n):
		return _f[n]
	_f[n] = sum([fact(int(c)) for c in list(str(n))])
	return _f[n]

def sf(n):
	#print "sf(",n,")"
	return sum([int(c) for c in str(f(n))])

def g(n):
	c = 1
	#print "g(",n,")"
	while True:
		_sf = sf(c)
		#print "++ {0} - f({0}) = {1}  sf({0}) = {2}".format(c, f(c), sf(c))
		if (_sf == n):
			#print "** ", n, _sf
			return c
		c += 1

def sg(n):
	print "looking for", n
	return sum([int(c) for c in str(g(n))])



#print g(3)
#for i in range(1):#
#	print fact(i*100)

print sum([sg(i+1) for i in range(150)])
#for i in range(151):
#	i += 1
#	print "i {0}: g({0})={3}".format(i, sf(i), f(i), g(i))
