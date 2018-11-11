#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_resolution;
uniform float u_time;

vec3 colorA = vec3(1.000,0.347,0.242);
vec3 colorB = vec3(0.587,0.912,0.631);

float my_pct(float x)
{
    x = mod(x, 1.0);
return 1.0-smoothstep(0.35, 0.4,x)
        +smoothstep(0.5, 0.8,x);     
}

void main() {
    vec3 color = vec3(0.0);

    float pct = my_pct(u_time/10.0);

    // Mix uses pct (a value from 0-1) to
    // mix the two colors
    color = mix(colorA, colorB, pct);

    gl_FragColor = vec4(color,1.0);
}
