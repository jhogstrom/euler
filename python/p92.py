import string
import datetime
_ends = {0:0, 1: 1, 89:89}

sq = dict([(i, i * i) for i in range(10)])

def SquareSum(n):
    k = 0
    while n:
        m = n % 10
        n = n/10
        k += sq[m]
    return k

def ep(n):
	#print "ep(%s)" % n
	if _ends.has_key(n):
		return _ends[n]

	#newn = sum([sq[c] for c in list(str(n))])
	newn = SquareSum(n)

	res = ep(newn)
	if not _ends.has_key(res):
		_ends[newn] = res
	return res

print datetime.time()

t, high = 0, 10000000
for i in xrange(high):
	if not i % 10000:
		print i
	if ep(i) == 89:
		t += 1;
print datetime.time()


print t,"/",high

