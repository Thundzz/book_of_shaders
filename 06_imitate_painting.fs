#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14159265359

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

vec3 colorA = vec3(0.113,0.220,0.912);
vec3 colorB = vec3(1.000,0.833,0.224);

float plot (vec2 st, float pct){
  return  smoothstep( pct-0.01, pct, st.y) -
          smoothstep( pct, pct+0.01, st.y);
}

void main() {
    vec2 st = gl_FragCoord.xy/u_resolution.xy;
    vec3 color = vec3(0.0);

    vec3 pct = vec3(st.x);

    
    float displacement = 0.2;
    //float etalement = 0.27;
    float etalement = (sin(u_time)+1.0)/2.0;
    pct.r = smoothstep(0.5-etalement,0.5, st.x-displacement) - smoothstep(0.5,.5 + etalement ,st.x-displacement);
    pct.g = (smoothstep(0.5-etalement,0.5, st.x-displacement) - smoothstep(0.5,.5 + etalement ,st.x-displacement))/1.5;
    pct.b = pow(st.x,0.5);

    
    
    pct.r *= -1.0 * st.y * (st.y - 2.0);
    pct.g *= -1.0 * st.y * (st.y - 2.0);
    
    pct.r *= (sin(u_time)+1.0)/2.0;
    pct.g *= (sin(u_time)+1.0)/2.0;
    color = mix(colorA, colorB, pct);
    
    // Plot transition lines for each channel
    color = mix(color,vec3(1.0,0.0,0.0),plot(st,pct.r));
    color = mix(color,vec3(0.0,1.0,0.0),plot(st,pct.g));
    color = mix(color,vec3(0.0,0.0,1.0),plot(st,pct.b));

    gl_FragColor = vec4(color,1.0);
}
