#ifdef GL_ES
precision mediump float;
#endif

uniform vec2 u_resolution;
uniform vec2 u_mouse;
uniform float u_time;

void main() {
    vec2 st = gl_FragCoord.xy/u_resolution;
    vec2 m = u_mouse/u_resolution;
    float base_blue = 0.600;
    float b = base_blue + 0.1;
    
    vec4 col;
    if (st.y >= m.y){
        col = vec4(0.2,0.2,0.2, 1);
    }
    else if (abs(st.x - fract(u_time*0.9)) <= 0.01)
    {
        col = vec4(0.183-0.02,0.255+0.1,b,1.000);
    }
    else
    {
        col = vec4(0.183,0.255,base_blue,1.000);
    }
    
    gl_FragColor = col;
}
