def fib():
    "unbounded generator, creates Fibonacci sequence"
    x = 0
    y = 1
    while 1:
        yield x
        x, y = y, x + y

def tailfib():
    "unbounded generator, creates Fibonacci sequence"
    x = 0
    y = 1
    while 1:
        yield x
        x, y = y, x + y % 1000000000

def ispandigital(n):
	return len(n) == 9 and not '0' in n

f = fib()
lasttail = 0
def isfrontpd(n, lasttail):
	while lasttail <= n:
		fn = f.next()
		lasttail += 1
	fn = str(fn)
	return ispandigital(set(list(fn[:9])))


i, tf = 0, tailfib()
while True:
	fn = str(tf.next())
	if True:#ispandigital(set(list(fn[-9:]))):
		#print i
		if (isfrontpd(i, i-1)):
			print i, "*"*20
		#exit()
	i += 1

# for i in range(10):
# 	print i, f.next()
# exit()
i = 0
while True:
	fn = str(f.next())
	if ispandigital(set(list(fn[:9]))) and ispandigital(set(list(fn[-9:]))):
		print i
		exit()
	i += 1
