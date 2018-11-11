#ifdef GL_ES
precision mediump float;
#endif

#define PI 3.14159265359

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

vec3 red = vec3(0.912,0.033,0.103);
vec3 orange = vec3(1.000,0.625,0.042);
vec3 yellow = vec3(1.000,0.984,0.009);
vec3 green = vec3(0.060,1.000,0.012);
vec3 blue = vec3(0.014,0.335,1.000);
vec3 violet = vec3(0.490,0.000,1.000);
vec3 pink = vec3(1.000,0.002,0.872);
vec3 white = vec3(1.,1.,1.);


float plot (vec2 st, float pct){
  return  smoothstep( pct-0.01, pct, st.y) -
          smoothstep( pct, pct+0.01, st.y);
}

void main() {
    vec3 COLOR_MASKS[8];
    COLOR_MASKS[0] = red;
    COLOR_MASKS[1] = orange;
    COLOR_MASKS[2] = yellow;
    COLOR_MASKS[3] = green;
    COLOR_MASKS[4] = blue;
    COLOR_MASKS[5] = violet;
    COLOR_MASKS[6] = pink;
    COLOR_MASKS[7] = white;
    
    vec2 st = gl_FragCoord.xy/u_resolution.xy;

    vec3 col1;
    vec3 col2;
    
    float x = st.x;
    if(x >= 0. && x <= 1./6.){
        col1 = COLOR_MASKS[0];
        col2 = COLOR_MASKS[1];
    } else if(x > 1./6. && x <= 2./6.){
        col1 = COLOR_MASKS[1];
        col2 = COLOR_MASKS[2];
    }else if(x > 2./6. && x <= 3./6.){
        col1 = COLOR_MASKS[2];
        col2 = COLOR_MASKS[3];
    }else if(x > 3./6. && x <= 4./6.){
        col1 = COLOR_MASKS[3];
        col2 = COLOR_MASKS[4];
    }else if(x > 4./6. && x <= 5./6.){
        col1 = COLOR_MASKS[4];
        col2 = COLOR_MASKS[5];
    }else if(x > 5./6. && x <= 6./6.){
        col1 = COLOR_MASKS[5];
        col2 = COLOR_MASKS[6];
    }
    
    vec3 color = mix(col1, col2, mod(st.x, 1.0/6.0)*6.0);

    gl_FragColor = vec4(color,1.0);
}
