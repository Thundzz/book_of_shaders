import matplotlib.pyplot as plt
import numpy as np
import math
# frac, whole = math.modf(2.5)

x = np.arange(0,10.01,0.01)
y = map(lambda x: 1. - abs(math.modf(x)[0] - 0.5) , x)
y2 = map(lambda x: 1. - abs(math.sin(2*math.pi * x )) , x)

# plt.plot(x, y)
# plt.plot(x, y2)
plt.plot(y, y2)
plt.show()



