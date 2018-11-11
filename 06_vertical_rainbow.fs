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
    
    vec2 st = gl_FragCoord.xy/u_resolution.xy;

    vec3 col1;
    vec3 col2;
    
    float x = st.x;
    if(x >= 0. && x <= 1./7.){
        col1 = COLOR_MASKS[0];
    } else if(x > 1./7. && x <= 2./7.){
        col1 = COLOR_MASKS[1];
    }else if(x > 2./7. && x <= 3./7.){
        col1 = COLOR_MASKS[2];
    }else if(x > 3./7. && x <= 4./7.){
        col1 = COLOR_MASKS[3];
    }else if(x > 4./7. && x <= 5./7.){
        col1 = COLOR_MASKS[4];
    }else if(x > 5./7. && x <= 6./7.){
        col1 = COLOR_MASKS[5];
    }else if(x > 6./7. && x <= 1.0){
        col1 = COLOR_MASKS[6];
    }  
    
    vec3 color = col1;

    gl_FragColor = vec4(color,1.0);
}
