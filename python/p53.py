def fac():
    "unbounded generator, creates Fibonacci sequence"
    x,c = 1,0
    while 1:        
        yield x
        c +=1
        x *=  c

f, _f = fac(), {}
for i in range(101):
	_f[i] = f.next()


def comb(n, r):
	return _f[n]/(_f[r]*_f[n-r])

#print comb(23, 10)
big = 0

for n in range(1, 101):
	for r in range(1, n):
		c = comb(n,r)
		if c > 1000000:
			print n, r, c
			big += 1;

		print n

print big
